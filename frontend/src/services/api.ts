import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:5130/'
});

export default api;