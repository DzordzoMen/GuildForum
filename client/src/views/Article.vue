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
        <b-row>

        <b-row v-if="article.photo != null">
          <b-col>
            <b-img rounded src="https://picsum.photos/1400/1100" fluid-grow alt="Test" />
          </b-col>
        </b-row>


        </b-row>
        <b-row>
          <b-col>
            <small class="text-muted">
              {{ article.postDate }}
            </small>
          </b-col>
        </b-row>

      </b-media>
    </b-card>

    <ul class="comment-area">
      <b-media v-for="comment in article.articleComments" v-bind:key="comment.commentId" tag="li">
        <b-img rounded slot="aside" blank blank-color="#abc" width="64" alt="placeholder" />
        
        <b-row>
          <b-col cols="1">
            <h4 class="mt-0 mb-1" @click="showUser(article.articleID)" id="user">
              {{ comment.nick }} 
            </h4>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
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
export default {
  name: 'article',
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
  },
};
</script>


<style lang="scss">
  .comment-area {
    & > li {
      margin-top: 25px;
    }
  }

  #user:hover {
    cursor: pointer;
    color:#88f;
    // blueviolet
  }
</style>
