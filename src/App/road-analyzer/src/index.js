import React from 'react';
import ReactDOM from 'react-dom';
import { applyMiddleware, createStore } from 'redux'
import { Provider } from 'react-redux'

import promise from 'redux-promise'
import thunk from 'redux-thunk'

import Routes from './main/routes';
import reducers from './main/reducers'
import { signalRRegisterCommands } from './main/signalRInvokeMiddleware'

import './index.css';
import 'bulma/css/bulma.css'

import * as serviceWorker from './serviceWorker';

const devTools = window.__REDUX_DEVTOOLS_EXTENSION__ 
&& window.__REDUX_DEVTOOLS_EXTENSION__()
const store = applyMiddleware(thunk, promise)(createStore)(reducers, devTools)
signalRRegisterCommands(store, () => {
    ReactDOM.render(
    <Provider store={store}>
        <Routes />
    </Provider>
, document.getElementById('root')
)});

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();