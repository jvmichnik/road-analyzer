import axios from 'axios'
const BASE_URL = 'http://localhost:8080/api'

export function getTrechos() {
    const request = axios.get(`${BASE_URL}/l/levantamentos`)
    return {
        type: 'TRECHOS_FETCHED',
        payload: request
    }
}