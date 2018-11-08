<template>
  <dir>
    <Menu />
    <b-container class="mt-3">
      <router-view />
    </b-container>
  </dir>
</template>

<script>
import Menu from '../components/Menu.vue'

export default {
  name: 'panel',
  components: {
    Menu,
  },
};
</script>
