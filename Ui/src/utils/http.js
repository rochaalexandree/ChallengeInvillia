import axios from 'axios'

export const api = 'http://localhost:5000'

const instance = axios.create({ baseURL: `${api}` });

instance.interceptors.response.use(
  config => config,
  // async (_err) => {}
)

export default instance
