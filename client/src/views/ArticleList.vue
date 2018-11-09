<template>
    <div>
      <b-row>
        <b-col class="article-wrapper">
          <b-card v-for="article in articles" v-bind:key="article.articleID">
            <b-row>
              <b-col @click="showArticleInfo(article.articleID)" id="title">
                <h4>
                  {{ article.title }}
                </h4>
              </b-col>
              <b-col offset-md="4">
                <b-col @click="showUser(article.userID)" id="author">
                  {{ article.author }}
                </b-col>

                <b-col>
                  <small class="text-muted">
                    {{ article.roleName }}
                  </small>
                </b-col>
              </b-col>
            </b-row>

            <b-row>
              <b-col>
                <p>
                  {{ article.content }}
                </p>
              </b-col>
            </b-row>

            <b-row v-if="article.photo != null">
              <b-col>
                <b-img rounded src="https://picsum.photos/400/100" fluid-grow alt="Test" />
              </b-col>
            </b-row>

            <b-row>
              <b-col>
                <small class="text-muted">
                  {{ article.postDate }}
                </small>
              </b-col>
            </b-row>
          </b-card>
        </b-col>
      </b-row>
    </div>
</template>

<script>
export default {
  name: 'articleList',
  data() {
    return {
      articles: [],
    };
  },
  created() {
    this.$http.get('/api/article')
      .then((response) => {
        this.articles = response.body;
      });
  },
  methods: {
    showArticleInfo(articleId) {
      this.$router.push(`/panel/article/${articleId}`);
    },
    showUser(userId) {
      this.$router.push(`/panel/user/${userId}`);
    }
  }
};
</script>


<style lang="scss">
  .article-wrapper {
    & > div {
      margin-bottom: 25px;
    }
  }

  #title:hover {
    cursor: pointer;
    color: dodgerblue;
  }

  #author:hover {
    cursor: pointer;
    color:#88f;
    // blueviolet
  }
</style>