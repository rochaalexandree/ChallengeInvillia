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
  user: {},
  isAuthenticated: false
};

const actions = {
  [AUTH_LOCAL]: (context, { email, password }) => {
    // important to return so then() can be used
    return http.post('auth/local', { email,  password })
      .then(({ data }) => { context.commit(AUTH_SUCCESS, data); })
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
  [AUTH_FAILURE]: (state, { message }) => {
    state.loading = false;
    state.error = message;
    state.isAuthenticated = false;
  },
  [AUTH_SUCCESS]: (state, { name, token, email }) => {
    state.loading = false;
    state.error = null;
    state.user = { name, token, email };
    state.isAuthenticated = true;
  },
  [UNAUTHENTICATE]: (state) => {
    state.user = {};
    state.isAuthenticated = false;
  }
};

const getters = {
  userData: state => ({ name: state.user.name, email: state.user.email }),
  loggedIn: state => state.user.token ? true : false,
};

export default {
  state: defaultState,
  getters,
  actions,
  mutations,
};
