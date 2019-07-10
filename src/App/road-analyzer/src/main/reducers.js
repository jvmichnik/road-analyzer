import { combineReducers } from 'redux'
import { reducer as ToastrReducer } from 'react-redux-toastr'

import HomeReducer from '../home/homeReducer'

const rootReducer = combineReducers({
    home: HomeReducer,
    toastr: ToastrReducer
})

export default rootReducer