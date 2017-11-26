import * as types from '../actions/types';
import { hashHistory } from 'react-router';
const INITIAL_STATE = {};

export function customerReducer(state = INITIAL_STATE, action: any) {
    switch (action.type) {        
        case types.GOT_CUSTOMERS:
            return { ...state, customers: action.customers };
        case types.GOT_CUSTOMERS_COUNT:
            return { ...state, customerCount: action.customerCount };
    }

    return state;
}