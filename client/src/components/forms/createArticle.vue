<template>
  <b-modal
    id="createArticle"
    title="Stwórz ogłoszenie"
    @ok="onSubmit"
  >
    <b-form @submit.stop.prevent="onSubmit">
      <b-form-group
        id="titleLabel"
        label="Tytuł ogłoszenia:"
        label-for="titleInput"
      >
        <b-form-input
          id="titleInput"
          type="text"
          v-model="form.title"
          required
          placeholder="Tytuł ogłoszenia"
        >
        </b-form-input>
      </b-form-group>

      <b-form-group
        id="contentLabel"
        label="Treść ogłoszenia:"
        label-for="contentInput"
      >
        <b-form-textarea
          id="contentInput"
          type="text"
          v-model="form.content"
          required
          :rows="5"
          :max-rows="10"
          placeholder="Treść ogłoszenia"
        >
        </b-form-textarea>
      </b-form-group>

      <b-form-file
        v-model="form.photo"
        :state="Boolean(form.photo)"
        accept="image/*"
        placeholder="Dodaj zdjęcie"
      />
      <div class="mt-3">Wybrane zdjęcie: {{form.photo && form.photo.name}}</div>

    </b-form>
  </b-modal>
</template>

<script>
export default {
  name: 'createArticle',
  data() {
    return {
      form: {
        title: '',
        content: '',
        userID: 1,  // TODO CHANGE 
        photo: null,
      },
    };
  },
  methods: {
    onSubmit(event) {
      this.$http.post('/api/article/', {
        title: this.form.title,
        content: this.form.content,
        postDate: new Date(),
        userID: this.form.userID,
        photo: this.form.photo,
      }).then(() => {
        console.log("k");
      });
    }
  }
};
</script>
