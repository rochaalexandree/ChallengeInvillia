import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/Login.vue'
import Dashboard from '../views/Dashboard.vue'
import RegisterGame from '../views/RegisterGame.vue'
import RegisterFriend from '../views/RegisterFriend.vue'

import store from '../store';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import(/* webpackChunkName: "about" */ '../views/Register.vue')
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Dashboard,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/register-game',
    name: 'RegistrarGame',
    component: RegisterGame,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/register-friend',
    name: 'RegistrarAmigo',
    component: RegisterFriend,
    meta: {
      requiresAuth: true
    }
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!store.getters.loggedIn) {
      return next({ path: '/', query: { redirect: to.fullPath } });
    }
    return next();
  }
  return next();
});

export default router
