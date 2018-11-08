import Vue from 'vue'
import Router from 'vue-router'

import Home from './views/Home.vue'
import Panel from './views/Panel.vue'
import About from './views/About.vue'
import ArticleList from './views/ArticleList.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
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
        }
      ]
    }
  ]
})
