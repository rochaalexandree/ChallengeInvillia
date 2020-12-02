<template>
    <div>
        <Nav/>
        <div class="register">
            <ValidationObserver v-slot="{ invalid }">
            <h2>Registrar Amigo</h2>
            <form  @submit.prevent="send">
                <ValidationProvider rules="required" v-slot="{ pristine, errors }">
                <Input
                    :value="Name"
                    @input="Name = $event"
                    type="text"
                    name="Name"
                    label="Nome"
                    :error="!!(!pristine && errors[0])"
                    :message="!pristine && errors[0] ? errors[0] : ''"
                />
                </ValidationProvider>
                <ValidationProvider rules="required|email" v-slot="{ pristine, errors }">
                <Input
                    :value="Email"
                    @input="Email = $event"
                    type="text"
                    name="Email"
                    label="Email"
                    :error="!!(!pristine && errors[0])"
                    :message="!pristine && errors[0] ? errors[0] : ''"
                />
                </ValidationProvider>
                <ValidationProvider rules="required" v-slot="{ pristine, errors }">
                <Input
                    :value="Age"
                    @input="Age = $event"
                    type="number"
                    name="Age"
                    label="Idade"
                    :error="!!(!pristine && errors[0])"
                    :message="!pristine && errors[0] ? errors[0] : ''"
                />
                </ValidationProvider>
                <button class="btn btn-primary btn-register" :disabled="invalid" type="submit">
                CADASTRAR AMIGO
                </button>
                <router-link class="router-link" to="/">
                <button type="button" class="btn btn-link">Voltar ➜</button>
                </router-link>
            </form>
            </ValidationObserver>
        </div>
    </div>
</template>



<script>
// @ is an alias to /src
import Input from '@/components/Input.vue'
import Nav from '@/components/Nav.vue'

import http from '../utils/http';

export default {
  name: 'RegisterGame',
  components: {
    Input,
    Nav
  },
  methods: {
    send: function() {
        console.log("teste");
        http.post(`api/friends`, { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`}},
        {
            Name: this.Name,
            Age: this.Age,
            Email: this.Email,
            Games: this.Game
        });
    },
  },
  computed: {
    
  },
  data: function() {
    return {
      Name: '',
      Age: '',
      Email: '',
      Game: [],
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