<template>
  <div>

  </div>
</template>

<script>
export default {
  name: 'event',
  data() {
    return {
      event: {}
    };
  },
  created() {
    // send cookie
    const id = this.$route.params.eventId;
    this.$http.get(`/api/event/${id}/memebers`)
      .then((response) => {
        this.event = response.body;
      });
  },
};
</script>
