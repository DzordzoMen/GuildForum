<template>
  <b-container class="form-wrapper">
    <b-form @submit.prevent="login">
      <h2>
        Logowanie
      </h2>

      <b-form-group label="Nazwa użytkownika">
        <b-form-input
          type="text"
          placeholder="Podaj swoją nazwe użytkownika"
          v-model.trim="form.userName"
          required
        />
      </b-form-group>

      <b-form-group label="Hasło">
        <b-form-input
          type="password"
          placeholder="Wprowadź swoje hasło"
          v-model="form.password"
          required
        />
      </b-form-group>

      <b-button type="submit" variant="primary">
        Zaloguj
      </b-button>

    </b-form>
  </b-container>
</template>

<script>
export default {
  name: 'authorization',
  data() {
    return {
      form: {
        userName: '',
        password: '',
      },
    };
  },
  methods: {
    login() {
      this.$http.post('api/account/login', {
        userName: this.form.userName,
        password: this.form.password,
      }).then((data) => {
        if (data.status == 200)
          this.$store.commit('setLoggedIn');
          // localStorage.setItem('userId', data)
          this.$router.push('panel');
      });
    },
  },
  created() {
    const userIsLoggedIn = localStorage.getItem('loggedIn');
    if (userIsLoggedIn === 'true') 
      this.$router.push('panel');
  },
};
</script>


<style lang="scss">
  .form-wrapper {
    margin-top: 40px;
    h2 {
      margin-bottom: 15px;
    }
  }
</style>
