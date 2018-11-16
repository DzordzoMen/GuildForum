<template>
  <div>
    <b-navbar toggleable="md" type="light" variant="light" sticky>

      <b-navbar-brand href="/">
        GuildForum
      </b-navbar-brand>

      <b-collapse is-nav id="menuNav">
        <b-navbar-nav class="ml-auto">

          <b-nav-item>
            <router-link to="/panel/articles">
              Articles
            </router-link>
          </b-nav-item>

          <b-nav-item>
            <router-link to="/panel/events">
              Events
            </router-link>
          </b-nav-item>

          <b-nav-item>
            <b-button
              size="sm"
              v-b-toggle.collapseOptions
            >
              =
            </b-button>
          </b-nav-item>

          <b-nav-item>
            <router-link to="/" v-if="this.loggedIn === false">
              Zaloguj się
            </router-link>
          </b-nav-item>

        </b-navbar-nav>
      </b-collapse>

    </b-navbar>

    <b-collapse
      id="collapseOptions"
    >
      <b-card>
        <b-button
          size="md"
          variant="success"
          v-b-modal.createArticle
          style="marginRight:10px;"
        >
        <!-- Dodać ikonki -->
          Create Article
        </b-button>
        <b-button
          size="md"
          variant="success"
          v-b-modal.createEvent
          style="marginRight:10px;"
        >
          Create Event
        </b-button>
      </b-card>
    </b-collapse>

    <create-article />
    <create-event />

  </div>
</template>


<script>
import CreateArticle from './forms/createArticle.vue';
import CreateEvent from './forms/createEvent.vue';

export default {
  name: 'menu',
  components: {
    CreateArticle,
    CreateEvent,
  },
  data() {
    return {
      loggedIn: false,
    };
  },  // TODO ZASTANOWIC SIE CO TUTAJ DAC
  created() {
    this.loggedIn = localStorage.getItem('loggedIn');
  },
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
