const INITIAL_STATE = { levantamentos:{} }

export default function(state = INITIAL_STATE, action) {
    switch (action.type) {
        case 'LOG_SENDED':   
            return {...state, levantamentos: { 
                ...state.levantamentos, 
                [action.payload.levantamentoId]: { 
                trecho: {...state.levantamentos[action.payload.levantamentoId].trecho, logs: [...state.levantamentos[action.payload.levantamentoId].trecho.logs, action.payload]},
                logActual: action.payload  
            } 
        } }
        case 'TRECHO_DETAIL_FETCHED':   
            return { levantamentos: { ...state.levantamentos, [action.payload.data.id]: { trecho: action.payload.data, logActual: action.payload.data.lastLog  } } }
        case 'LEVANTAMENTO_CONCLUDED': 
            console.log(action.payload);  
            return {...state, levantamentos: { 
                ...state.levantamentos, 
                [action.payload.id]: { 
                trecho: {...state.levantamentos[action.payload.id].trecho, end: action.payload.end},
                logActual: {...state.levantamentos[action.payload.id].logActual}
            } 
        } }
        default:
            return state
    }
}