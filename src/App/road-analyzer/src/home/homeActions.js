import axios from 'axios'

const BASE_URL = 'http://ec2-18-228-156-207.sa-east-1.compute.amazonaws.com:8080/api'
//const BASE_URL = 'http://localhost:8080/api'

export function getTrechos() {
    const request = axios.get(`${BASE_URL}/l/levantamentos`)
    return {
        type: 'TRECHOS_FETCHED',
        payload: request
    }
}