<template>
    <div>
        <Nav/>
        <div class="register">
            <ValidationObserver v-slot="{ invalid }">
            <h2>Registrar Game</h2>
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
                <ValidationProvider rules="required" v-slot="{ pristine, errors }">
                <Input
                    :value="Type"
                    @input="Type = $event"
                    type="text"
                    name="Type"
                    label="Type"
                    :error="!!(!pristine && errors[0])"
                    :message="!pristine && errors[0] ? errors[0] : ''"
                />
                </ValidationProvider>
                <button class="btn btn-primary btn-register" :disabled="invalid" type="submit">
                CADASTRAR GAME
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
import http from '../utils/http';
import Nav from '@/components/Nav';

export default {
  name: 'RegisterGame',
  components: {
    Input,
    Nav
  },
  methods: {
    send: function() {
        http.post(`api/game`, {
                Name: this.Name,
                Type: this.Type,
            },
            { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`}}
        )
     },
  },
  computed: {
    
  },
  data: function() {
    return {
        Name: '',
        Type: ''
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