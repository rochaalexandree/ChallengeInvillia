<template>
  <div>
    <nav class="navbar navbar-light bg-light">
      <a class="navbar-brand">Bem vindo {{ name }} </a>
      <router-link to="/dashboard">
        Dashboard
      </router-link>
      <router-link to="/register-friend">
        Registrar Amigo
      </router-link>
      <router-link to="/register-game">
        Registrar Game
      </router-link>
      <form class="form-inline">
        <button class="form-control mr-sm-2 btn btn-danger" @click="logout">
          logout
        </button>
      </form>
    </nav>
  </div>
</template>

<script>
// @ is an alias to /src
import { LOGOUT } from '@/store/actions.type.js';

export default {
  name: 'Nav',
  data: function() {
    return {
      name: this.$store.state.auth.userName,
    }
  },
  methods: {
    logout: function() {
      this.$store
        .dispatch(LOGOUT)
        .then(() => {
          this.$router.push({ path: '/' })
        })
        .catch(() => {});
    }
  },
}
</script>
