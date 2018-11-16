<template>
  <b-modal
    id="createEvent"
    title="Stwórz event"
    @ok="onSubmit"
  >
    <b-form @submit.stop.prevent="onSubmit">
      <b-form-group
        id="eventNameLabel"
        label="Nazwa wydarzenia:"
        label-for="eventNameInput"
      >
        <b-form-input
          id="eventNameInput"
          type="text"
          v-model="form.eventName"
          required
          placeholder="Nazwa wydarzenia"
        >
        </b-form-input>
      </b-form-group>

      <b-form-group
        id="eventDescriptionLabel"
        label="Opis wydarzenia:"
        label-for="eventDescriptionArea"
      >
        <b-form-textarea
          id="eventDescriptionArea"
          v-model="form.eventDescription"
          placeholder="Opis wydarzenia"
          :rows="3"
          :max-rows="6"
        >
        </b-form-textarea>
      </b-form-group>

      <!-- TODO CALENDAR -->

    </b-form>
  </b-modal>
</template>

<script>
export default {
  name: 'createEvent',
  data() {
    return {
      form: {
        eventName: '',
        eventDescription: '',
        eventDate: '',
        userId: 1,  // TODO CHANGE
      }
    };
  },
  methods: {
    onSubmit() {
      this.$http.post('/api/event', {
        eventName: this.form.eventName,
        eventDescription: this.form.eventDescription,
        eventDate: new Date(),
        userId: this.form.userId,
      }).then(() => {
        // TODO
      });
    }
  },
}
</script>

