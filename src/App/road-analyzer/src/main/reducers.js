import { combineReducers } from 'redux'

import HomeReducer from '../home/homeReducer'

const rootReducer = combineReducers({
    home: HomeReducer
})

export default rootReducer