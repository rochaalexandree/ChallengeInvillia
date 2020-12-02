import http from '../../utils/http';
import { AUTH_LOCAL, AUTH_GOOGLE, LOGOUT } from '../actions.type';
import {
  AUTH,
  AUTH_SUCCESS,
  AUTH_FAILURE,
  UNAUTHENTICATE
} from '../mutations.type';

const defaultState = {
  error: null,
  loading: false,
  userName: null,
  isAuthenticated: false,
  token: null
};

const actions = {
  [AUTH_LOCAL]: (context, { UserName,  Password, sucessCallback }) => {
    // important to return so then() can be used
    return http.post('api/user/Login', { UserName,  Password })
      .then(({ data }) => { context.commit(AUTH_SUCCESS, data); sucessCallback();})
      .catch(error => { context.commit(AUTH_FAILURE, error); });
  },
  [AUTH_GOOGLE]: (context, payload) => {
    return context.commit(AUTH_SUCCESS, payload);
  },
  [LOGOUT]: (context) => {
    return context.commit(UNAUTHENTICATE);
  }
};

const mutations = {
  [AUTH]: (state) => {
    state.loading = true;
  },
  [AUTH_FAILURE]: (state) => {
    state.loading = false;
    state.error = "Login ou senha incorretos";
    state.isAuthenticated = false;
    state.userName = null;
  },
  [AUTH_SUCCESS]: (state, { token, user }) => {
    state.loading = false;
    state.error = null;
    state.userName = user.userName;
    state.token = token;
    state.isAuthenticated = true;
  },
  [UNAUTHENTICATE]: (state) => {
    state.userName = null;
    state.isAuthenticated = false;
  }
};

const getters = {
  userData: state => ({ name: state.user.name, email: state.user.email }),
  loggedIn: state => state.isAuthenticated ? true : false,
};

export default {
  state: defaultState,
  getters,
  actions,
  mutations,
};
