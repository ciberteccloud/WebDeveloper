import * as React from 'react';
import {Route, Router, IndexRoute, hashHistory} from 'react-router';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware, compose } from 'redux';
import reduxThunk from 'redux-thunk';
import reducers from './reducers/rootReducer';
import DefaultParams from './defaultParams';

import Login from "./components/Login";
import NotFound from "./components/404";

const createStoreWithMiddleware = applyMiddleware(reduxThunk)(createStore);
const store = createStoreWithMiddleware(reducers, DefaultParams());

export class CustomersApp extends React.Component<any, any> {
    render() {
        return (
            <Provider store={store}>
                <Router history={hashHistory}>
                    <Route path="/" component={Login}/>
                    <Route path="*" component={NotFound} />
                </Router>   
            </Provider>
        );
    }
}
