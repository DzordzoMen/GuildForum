import Vue from 'vue';
import Router from 'vue-router';

import Authorization from './views/Authorization.vue';
import Panel from './views/Panel.vue';
import About from './views/About.vue';
import User from './views/User.vue';
import ArticleList from './views/ArticleList.vue';
import Article from './views/Article.vue';
import EventList from './views/EventList.vue';
import Event from './views/Event.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'authorization',
      component: Authorization,
    },
    {
      path: '/panel',
      name: 'panel',
      component: Panel,
      children: [
        {
          path: '/panel/about',
          name: 'about',
          component: About,
        },{
          path: '/panel/articles',
          name: 'articleList',
          component: ArticleList,
        },{
          path: '/panel/article/:articleId',
          name: 'article',
          component: Article,
        },{
          path: '/panel/user/:userId',
          name: 'user',
          component: User,
        },{
          path: '/panel/events',
          name: 'eventList',
          component: EventList,
        },{
          path: '/panel/event/:eventId',
          name: 'event',
          component: Event,
        }
      ]
    }
  ]
});
