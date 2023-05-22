<template>
  <HeaderRouter />
  <router-view />
</template>

<script>
  import HeaderRouter from './components/Header-Router.vue'

export default {
  name: 'App',
  components: {
    HeaderRouter,
  }
}
</script>
