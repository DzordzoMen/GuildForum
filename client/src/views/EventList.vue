<template>
  <div>
    <b-row>
      <b-col class="event-wrapper">
        <b-card v-for="event in events" v-bind:key="event.eventID">
          <b-row>
            <b-col @click="getEventMembers(event.eventID)">
              {{ event.eventName }}
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              {{ event.eventDescription }}
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              {{ event.eventDate }}
            </b-col>
          </b-row>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  name: 'eventList',
  data() {
    return {
      events: [],
    };
  },
  methods: {
    getEventMembers(eventId) {
      this.$router.push(`/panel/event/${eventId}`);
    }
  },
  created() {
    this.$http.get('/api/event')
      .then((response) => {
        this.events = response.body;
      });
  }
};
</script>

<style lang="scss">
  .event-wrapper {
    & > div {
      margin-bottom: 25px;
    }
  }
</style>

