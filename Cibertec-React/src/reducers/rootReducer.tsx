import { combineReducers } from 'redux';
import { loginReducer } from './authentication';


const rootReducer = combineReducers({
    loginReducer
});

export default rootReducer;