<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<style>
  html {
    box-sizing: border-box;
    --bs-light-color: #f8f9fa;
    --bs-info-color: #17a2b8; 
    --bs-success-color: #28a745; 
    --bs-danger-color: #dc3545; 
    --bs-dark-color: #343a40; 
    --bs-warning-color: #ffc107; 
    --bs-secondary-color: #6c757d; 
    --bs-primary-color: #007bff; 
  }
  *, *:before, *:after {
    box-sizing: inherit;
  }
  body #app {
    min-height: 100vh;
    background-color: var(--bs-light-color);
  }
</style>
