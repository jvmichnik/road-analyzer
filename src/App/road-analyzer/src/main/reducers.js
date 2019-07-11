import { combineReducers } from 'redux'
import { reducer as ToastrReducer } from 'react-redux-toastr'

import HomeReducer from '../home/homeReducer'
import DetailReducer from '../detail/detailReducer';

const rootReducer = combineReducers({
    home: HomeReducer,
    detail: DetailReducer,
    toastr: ToastrReducer
})

export default rootReducer