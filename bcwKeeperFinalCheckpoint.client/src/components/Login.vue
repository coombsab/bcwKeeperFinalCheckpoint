<template>
  <span class="navbar-text">
    <button class="login-btn btn text-visible text-uppercase my-2 my-lg-0" @click="login" v-if="!user.isAuthenticated">
      Login
    </button>
    <div v-else>
      <LoginDropMenu />
    </div>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
import LoginDropMenu from "./LoginDropMenu.vue"
export default {
    setup() {
        return {
            user: computed(() => AppState.user),
            async login() {
                AuthService.loginWithPopup();
            },
        };
    },
    components: { LoginDropMenu }
}
</script>

<style lang="scss" scoped>
@media screen and (min-width: 768px) {
  .login-btn:hover { 
    color: white !important;
  }
}
</style>
