import * as types from './types';
import axios from 'axios';
import { Dispatch } from "redux";
import * as URLSearchParams from 'url-search-params'

let apiUrl = 'http://localhost/Cibertec.WebApi';

export function loginUser(email: string, password: string) {
    return function (dispatch: any) {
        let params = new URLSearchParams();
        params.append('grant_type', 'password');
        params.append('username', email);
        params.append('password', password);        
        axios.post(`${apiUrl}/token` , params)
            .then(response => {
                dispatch({
                    type: types.GOT_TOKEN,
                    token: response.data.access_token
                });
            })
            .catch((error) => { console.log(error) });
    }
}


export function getCustomerList(token: string, page: number, pageSize: number) {
    return function (dispatch: any) {
        let config = { headers: { Authorization: `Bearer ${token}` }};        
        axios.get(`${apiUrl}/customer/list/${page}/${pageSize}`, config)
            .then(response => {
                dispatch({
                    type: types.GOT_CUSTOMERS,
                    customers: response.data
                });
            })
            .catch((error) => { console.log(error) });
    }
}

export function getCustomerCount(token: string) {
    return function (dispatch: any) {
        let config = { headers: { Authorization: `Bearer ${token}` }};                
        axios.get(`${apiUrl}/customer/count`, config)
            .then(response => {                
                dispatch({
                    type: types.GOT_CUSTOMERS_COUNT,
                    customerCount: response.data
                });
            })
            .catch((error) => { console.log(error) });
    }
}