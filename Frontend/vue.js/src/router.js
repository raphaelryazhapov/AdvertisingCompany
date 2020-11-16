import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

import Companies from "./components/Companies";

let router = new Router({
    routes: [
        {
            path: '/Companies',
            name: 'Companies',
            component: Companies
        },
    ]
});

export default router;