import Vue from 'vue'
import { ValidationProvider, ValidationObserver, extend } from 'vee-validate';
import { required, email } from 'vee-validate/dist/rules';

export default () => {
  Vue.component('ValidationProvider', ValidationProvider);
  Vue.component('ValidationObserver', ValidationObserver);
  
  extend('email', {
    ...email,
    message: 'Email inválido'
  });
  
  extend('required', {
    ...required,
    message: 'Esse campo é necessário'
  });
}

