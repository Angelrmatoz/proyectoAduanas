import axios from 'axios';

/**
 * Cliente Axios configurado para realizar peticiones a la API
 */
const apiClient = axios.create({
  baseURL: 'http://localhost:3001/api', // URL base de la API
  headers: {
    'Content-Type': 'application/json',
  },
  // Asegurar que las credenciales se envíen con las solicitudes
  withCredentials: true,
});

// Interceptor para manejar errores globalmente
apiClient.interceptors.response.use(
  response => response,
  error => {
    const { response } = error;
    if (response && response.status >= 400) {
      console.error('Error en la petición:', response.data);
    }
    return Promise.reject(error);
  }
);

export default apiClient;
