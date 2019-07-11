import axios from 'axios'

const BASE_URL = 'http://localhost:8080/api'

export function getLogs(levantamentoId) {
    const request = axios.get(`${BASE_URL}/l/levantamentos/${levantamentoId}/logs`)
    return {
        type: 'TRECHO_DETAIL_FETCHED',
        payload: request
    }
}