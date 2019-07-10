import { sortListLevantamentos } from '../common/functions/sort'

const INITIAL_STATE = { trechos: [], adicionado:{} }



export default function(state = INITIAL_STATE, action) {
    switch (action.type) {
        case 'TRECHOS_FETCHED':
            return { ...state, trechos: (action.payload.data || []).sort(sortListLevantamentos) }
        case 'LEVANTAMENTO_STARTED':
            return { trechos: [action.payload, ...state.trechos].sort(sortListLevantamentos), adicionado: action.payload  }
        case 'LEVANTAMENTO_CONCLUDED':
            return { ...state.trechos , trechos: [action.payload, ...state.trechos.filter(x => x.id !== action.payload.id)].sort(sortListLevantamentos)  }
        default:
            return state
    }
}