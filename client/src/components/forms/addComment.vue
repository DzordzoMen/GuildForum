<template>
  <b-form @submit="onSubmit">
    <b-form-group
      id="commentLabel"
      label="Dodaj komentarz:"
      label-for="commentInput"
    >
      <b-form-input
        id="commentInput"
        type="text"
        v-model="form.commentContent"
        required
        placeholder="Treść komentarza"
      />
    </b-form-group>
    <b-button type="submit" variant="primary">Wyślij</b-button>
  </b-form>
</template>

<script>
export default {
  name: 'addComment',
  data() {
    return {
      form: {
        commentContent: '',
      }
    };
  },
  props: {
    articleId: null,
  },
  methods: {
    onSubmit(event) {
      // const id = this.$parent.article.articleID;
      const id = this.articleId;
      this.$http.post(`/api/article/${id}/comment`, {
        content: this.form.commentContent,
        postDate: new Date(), // TODO problem
        userID: 2,
      });
    },
  },
};
</script>
