import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import type { Product, CreateProductDTO, UpdateProductDTO } from '@/types/Product';
import { ProductService } from '@/api/productService';

export const useProductStore = defineStore('products', () => {
  // Estado
  const products = ref<Product[]>([]);
  const isLoading = ref(false);
  const error = ref<string | null>(null);
  const selectedProduct = ref<Product | null>(null);

  // Getters
  const getProductById = computed(() => {
    return (id: number) => products.value.find(product => product.id === id);
  });

  const totalProducts = computed(() => products.value.length);

  // Acciones
  async function fetchProducts() {
    isLoading.value = true;
    error.value = null;

    try {
      products.value = await ProductService.getAll();
    } catch (err: Error | unknown) {
      const errorMessage = err instanceof Error ? err.message : 'Error al cargar los productos';
      error.value = errorMessage;
      console.error(error.value);
    } finally {
      isLoading.value = false;
    }
  }

  async function fetchProductById(id: number) {
    isLoading.value = true;
    error.value = null;

    try {
      selectedProduct.value = await ProductService.getById(id.toString());
    } catch (err: Error | unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al cargar el producto con ID ${id}`;
      error.value = errorMessage;
      console.error(error.value);
    } finally {
      isLoading.value = false;
    }
  }

  async function createProduct(product: CreateProductDTO) {
    isLoading.value = true;
    error.value = null;

    try {
      const newProduct = await ProductService.create(product);
      products.value.push(newProduct);
      return newProduct;
    } catch (err: Error | unknown) {
      const errorMessage = err instanceof Error ? err.message : 'Error al crear el producto';
      error.value = errorMessage;
      console.error(error.value);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  async function updateProduct(product: UpdateProductDTO) {
    isLoading.value = true;
    error.value = null;

    try {
      const updatedProduct = await ProductService.update(product.id.toString(), product);
      const index = products.value.findIndex(p => p.id === product.id);

      if (index !== -1) {
        products.value[index] = updatedProduct;
      }

      return updatedProduct;
    } catch (err: Error | unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al actualizar el producto con ID ${product.id}`;
      error.value = errorMessage;
      console.error(error.value);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  async function deleteProduct(id: number) {
    isLoading.value = true;
    error.value = null;

    try {
      await ProductService.delete(id.toString());
      products.value = products.value.filter(product => product.id !== id);
    } catch (err: Error | unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al eliminar el producto con ID ${id}`;
      error.value = errorMessage;
      console.error(error.value);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  return {
    // Estado
    products,
    isLoading,
    error,
    selectedProduct,
    // Getters
    getProductById,
    totalProducts,
    // Acciones
    fetchProducts,
    fetchProductById,
    createProduct,
    updateProduct,
    deleteProduct,
  };
});
