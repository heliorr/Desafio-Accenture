<template>
  <main class="flex flex-col h-screen justify-between">
    <HeaderRouter />
    <router-view />
    <FooterRouter />
  </main>
</template>

<script>
  import HeaderRouter from './components/Header-Router.vue'
  import FooterRouter from './components/Footer-Router.vue'


export default {
  name: 'App',
  components: {
    HeaderRouter,
    FooterRouter,
  }
}
</script>

<style>
  body {
    background-color: rgb(214, 214, 214);
  }
</style>
