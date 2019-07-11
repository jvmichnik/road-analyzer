import React from 'react';
import { BrowserRouter as Router, Redirect, Route } from "react-router-dom";

import Home from '../home/home'
import Details from '../detail/detail'
import { MessageContainer } from '../common/msg/messages'

export default props => (
    <Router>
        <Route exact path='/' component={Home} />
        <Route exact path='/detail/:id' component={Details} />
        <Redirect from='*' to='/' />
        <MessageContainer />
    </Router>
)