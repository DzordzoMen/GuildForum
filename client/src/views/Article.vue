<template>
  <div>
    <b-card
      border-variant="secondary"
      header-border-variant="secondary"
    >
      <b-media>

        <b-row>
          <b-col>
            <h4>
              {{ article.title }}
            </h4>
          </b-col>
          <b-col offset-md="4">
            <b-col id="user">
              {{ article.author }}
            </b-col>
            <b-col>
              <small class="text-muted">
                {{ article.roleName }}
              </small>
            </b-col>
          </b-col>
        </b-row>

        <b-col style="padding-top:20px;">
          <p>
            {{ article.content }}
          </p>
        </b-col>

        <b-row v-if="article.photo != null" style="padding: 10px 0;">
          <b-col>
            <b-img rounded src="https://picsum.photos/1400/1100" fluid-grow alt="Test" />
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <small class="text-muted">
              {{ article.postDate }}
            </small>
          </b-col>

          <b-col offset-md="1" style="margin-right:10px;">
            <b-button
              size="sm"
              variant="warning"
              v-b-toggle.addComment
            >
              Dodaj komentarz
            </b-button>
            <b-button
              size="sm"
              variant="danger"
              style="margin-left:5px;"
              v-if="article.userID === 1"
              v-b-modal.deleteArticle
            >
              Usuń 
            </b-button>
          </b-col>
        </b-row>

      </b-media>
    </b-card>

    <b-collapse id="addComment">
      <b-card
        border-variant="secondary"
        style="border-top:none;"
      >
        <add-comment :article-id="article.articleID" />
      </b-card>
    </b-collapse>

    <b-modal
      id="deleteArticle"
      title="Potiwerdzenie usunięcia artykułu"
      hide-footer
    >
      <div>
        <p>
          Czy aby na pewno chesz usunąć "<i>{{ article.title }}</i>"?
        </p>
      </div>
      <b-button
        variant="danger"
        @click="removeArticle(article.articleID)"
        block
      >
        Usuń artykuł
      </b-button>
    </b-modal>

    <ul class="comment-area">
      <b-media v-for="comment in article.articleComments" v-bind:key="comment.commentId" tag="li">
        <b-img rounded slot="aside" blank blank-color="#abc" width="64" alt="placeholder" />
        
        <b-row>
          <b-col cols="1">
            <!-- TODO CHANGE ARTICLEID TO USERID -->
            <h6 class="mt-0 mb-1" @click="showUser(article.articleID)" id="user">
              {{ comment.nick }} 
            </h6>
          </b-col>
        </b-row>

        <b-row>
          <b-col style="margin-left:10px;">
            <p>
              {{ comment.content }}
            </p>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <small class="text-muted">
              {{ comment.postDate }}
            </small>
          </b-col>
        </b-row>
      </b-media>
    </ul>

  </div>
</template>


<script>
import AddComment from '../components/forms/addComment.vue';

export default {
  name: 'article',
  components: {
    AddComment,
  },
  data() {
    return {
      article: {
        // articleId: Number,
        // author: String,
        // userId: Number,
        // roleName: String,
        // title: String,
        // content: String,
        // postDate: Date,
        // photo: String,
        // articleComments: [],
      },
    };
  },
  created() {
    const id = this.$route.params.articleId;
    this.$http.get(`/api/article/${id}`)
      .then((response) => {
        this.article = response.body;
      });
  },
  methods: {
    showUser(userId) {
      this.$router.push(`/panel/user/${userId}`);
    },
    removeArticle(id) {
      this.$http.delete(`/api/article/${id}`)
        .then(() => {
          this.$router.push('/panel/articles');
        });
    }
  },
};
</script>


<style lang="scss">
  .comment-area {
    & > li {
      margin-top: 25px;
    }
  }
  #user {
    color: #111;
  }
  #user:hover {
    cursor: pointer;
    color:#88f;
    // blueviolet
  }
</style>
