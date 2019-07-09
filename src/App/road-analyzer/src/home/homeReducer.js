import { sortListLevantamentos } from '../common/functions/sort'

const INITIAL_STATE = {trechos: []}



export default function(state = INITIAL_STATE, action) {
    console.log(action);
    switch (action.type) {
        case 'TRECHOS_FETCHED':
            return { ...state, trechos: action.payload.data.sort(sortListLevantamentos) }
        case 'LEVANTAMENTO_STARTED':
            return { ...state.trechos , trechos: [action.payload, ...state.trechos].sort(sortListLevantamentos)  }
        case 'LEVANTAMENTO_CONCLUDED':
            return { ...state.trechos , trechos: [action.payload, ...state.trechos.filter(x => x.id != action.payload.id)].sort(sortListLevantamentos)  }
        default:
            return state
    }
}