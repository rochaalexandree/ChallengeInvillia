import Vue from 'vue'
import VueRouter from 'vue-router'
// import Login from '../views/Login.vue'
import Dashboard from '../views/Dashboard.vue'
import store from '../store';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Dashboard
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
