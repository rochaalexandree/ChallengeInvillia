<template>
  <div class="form-group">
    <label :class="`${error ? 'text-danger' : ''}`" :for="name"> {{ label }} </label>
    <input :type="type" :class="`form-control ${error ? 'is-invalid' : ''}`" :id="name" v-model="inputValue" />
    <div v-if="message" :class="error ? 'invalid-feedback' : ''">
      {{ message }}
    </div>
  </div>
</template>


<script>
export default {
  props: {
    value: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: 'text',
    },
    name: String,
    label: String,
    error: Boolean,
    message: String
  },
  computed: {
    inputValue: {
      get() { return this.value; },
      set(value) { this.$emit('input', value); }
    }
  }
}
</script>
