<template>
  <div class="register">
    <ValidationObserver v-slot="{ invalid }">
      <h2>Registrar</h2>
      <form  @submit.prevent="send">
        <ValidationProvider rules="required" v-slot="{ pristine, errors }">
          <Input
            :value="name"
            @input="name = $event"
            type="text"
            name="name"
            label="Nome"
            :error="!!(!pristine && errors[0])"
            :message="!pristine && errors[0] ? errors[0] : ''"
          />
        </ValidationProvider>
        <ValidationProvider rules="required|email" v-slot="{ pristine, errors }">
          <Input
            :value="email"
            @input="email = $event"
            type="email"
            name="email"
            label="Email"
            :error="!!(!pristine && errors[0])"
            :message="!pristine && errors[0] ? errors[0] : ''"
          />
        </ValidationProvider>
        <ValidationProvider rules="required" v-slot="{ pristine, errors }">
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
        <ValidationProvider rules="required" v-slot="{ pristine, errors }">
          <Input
            :value="confirmPassword"
            @input="confirmPassword = $event"
            type="password"
            name="confirm-password"
            label="Confirmar Senha"
            :error="!!(!pristine && (errors[0] || password !== confirmPassword))"
            :message="confirmPasswordMessage(pristine, errors)"
          />
        </ValidationProvider>
        <button class="btn btn-primary btn-register" :disabled="invalid" type="submit">
          CADASTRAR
        </button>
        <router-link class="router-link" to="/">
          <button type="button" class="btn btn-link">Voltar ➜</button>
        </router-link>
      </form>
    </ValidationObserver>
  </div>
</template>



<script>
// @ is an alias to /src
import Input from '@/components/Input.vue'
import http from '../utils/http';

export default {
  name: 'Register',
  components: {
    Input
  },
  methods: {
  send: function() {
      http.post('api/user/register', {
        UserName: this.userName,
        Password: this.password,
        Email: this.email,
        FullName: this.name
      })
      .then(function () {
        this.$router.push({ path: '/dashboard' })
      })
      .catch(function () {});
    },
    confirmPasswordMessage: function(pristine, errors) {
      if (!pristine && this.password !== this.confirmPassword) {
        return 'Os passwords devem ser iguais';
      }
      return (!pristine && errors[0])? errors[0] : '';
    }
  },
  computed: {
    
  },
  data: function() {
    return {
      email: '',
      password: '',
      name: '',
      confirmPassword: '',
      userName: ''
    }
  }
}
</script>

<style scoped>
  .register > span { /* validation observer */
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    min-height: 100vh;
  }
  .register form {
    min-width: 320px;
    max-width: 400px;
    width: 100%;
    min-height: 400px;
    padding: 32px;
  }
  .register .btn-register {
    width: 100%;
    margin-top: 12px;
  }
  .router-link {
    display: block;
    margin-left: auto;
    width: fit-content;
  }
  .register .btn-link {
    padding-left: 0;
    padding-top: 0;
    margin-top: 6px;
  }
</style>