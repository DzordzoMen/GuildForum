<template>
  <div>
    <b-row>
      <b-col>Tutaj</b-col>
      <b-col>Jeszcze</b-col>
      <b-col>Tego</b-col>
      <b-col>Nie</b-col>
      <b-col>Ma</b-col>
    </b-row>
    <b-img src="https://picsum.photos/1400/1100" fluid-grow="" alt="sad" />
  </div>
</template>

<script>
export default {
  name: 'user',
  data() {
    return {
      user: {},
    };
  },
  created() {
    // const id = this.$route.params.userId;
    // this.$http.get(`/api/user/${id}`)
    //   .then((response) => {
    //     this.article = response.body;
    //   });
    // console.log(id);
  },
}
</script>
