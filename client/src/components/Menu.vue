<template>
  <b-navbar toggleable="md" type="light" variant="light" sticky>

    <b-navbar-brand href="/">
      GuildForum
    </b-navbar-brand>

    <b-collapse is-nav id="menuNav">
      <b-navbar-nav class="ml-auto">

        <b-nav-item>
          <router-link to="/panel/about">
            About
          </router-link>
        </b-nav-item>

        <b-nav-item>
          <router-link to="/panel/articles">
            Articles
          </router-link>
        </b-nav-item>

        <b-nav-item>
          <router-link to="/panel">
            Back
          </router-link>
        </b-nav-item>

        <b-nav-item>
          <router-link to="/" v-if="true">
            Zaloguj się
          </router-link>
        </b-nav-item>

      </b-navbar-nav>
    </b-collapse>

  </b-navbar>
</template>


<script>
export default {
  name: 'menu',
};
</script>


<style lang="scss">
.menu-wrapper {
  position: fixed;
  left: 0;
  top: 0;
  bottom: 0;
  padding: 25px 0;
  width: 225px;
  background: #f1f1f1;
  text-align: center;
}
</style>
