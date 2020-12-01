<template>
  <div class="login">
    <ValidationObserver v-slot="{ invalid }">
      <h2>Acessar</h2>
      <form  @submit.prevent="send">
        <ValidationProvider rules="required|userName" v-slot="{ pristine, errors }">
          <Input
            :value="userName"
            @input="userName = $event"
            type="userName"
            name="userName"
            label="Usuário"
            :error="!!(!pristine && errors[0])"
            :message="!pristine && errors[0] ? errors[0] : ''"
          />
        </ValidationProvider>
        <ValidationProvider rules="required" v-slot="{ pristine, errors }">
          <Input
            :value="password"
            @input="password = $event"
            type="password"
            name="password"
            label="Senha"
            :error="!!(!pristine && errors[0])"
            :message="!pristine && errors[0] ? errors[0] : ''"
          />
        </ValidationProvider>
        <button class="btn btn-primary btn-login" :disabled="invalid" type="submit">
          LOGIN
        </button>
        <router-link to="/register" class="link-register">
          <button type="button" class="btn btn-link btn-register">Não tem uma conta? <b>Inscreva-se</b></button>
        </router-link>
      </form>
    </ValidationObserver>
  </div>
</template>

<script>
// @ is an alias to /src
import Input from '@/components/Input.vue'
import { AUTH_LOCAL } from '@/store/actions.type.js'

export default {
  name: 'Home',
  components: {
    Input
  },
  methods: {
    send: function() {
      this.$store
        .dispatch(AUTH_LOCAL, { UserName: this.userName, Password: this.password })
        .then(() => {
          this.$router.push({ path: '/dashboard' })
        })
        .catch(() => {});
    },
  },
  data: function() {
    return {
      userName: '',
      password: '',
    }
  },
}
</script>

<style scoped>
  .login > span { /* validation observer */
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    min-height: 100vh;
  }
  .login form {
    min-width: 320px;
    max-width: 400px;
    width: 100%;
    min-height: 400px;
    padding: 32px;
  }
  .login .btn-login {
    width: 100%;
    margin-top: 12px;
  }
  .login .btn-link {
    padding-left: 0;
    padding-top: 0;
    padding-bottom: 0;
  }
  .login .btn-pass {
    margin-top: 6px;
  }
  .login .link-register {
    text-align: center;
    display: block;
    width: 100%;
    margin-top: 24px;
  }
</style>