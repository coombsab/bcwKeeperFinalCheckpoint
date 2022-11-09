<template>
  <span class="navbar-text">
    <button class="login-btn btn text-visible text-uppercase my-2 my-lg-0" @click="login" v-if="!user.isAuthenticated">
      Login
    </button>
    <div v-else>
      <!-- <div class="dropdown dropstart my-2 my-lg-0">
        <div type="button" class="bg-dark border-0 selectable no-select circle" data-bs-toggle="dropdown"
          aria-expanded="false">
          <div v-if="account.picture || user.picture">
            <img :src="account.picture || user.picture" alt="account photo" class="account-photo circle" />
          </div>
        </div>
        <div class="dropdown-menu dropdown-menu-lg-left p-0" aria-labelledby="authDropdown">
          <div class="list-group">
            <router-link :to="{ name: 'Account' }">
              <div class="list-group-item dropdown-item list-group-item-action">
                Manage Account
              </div>
            </router-link>
            <div class="list-group-item dropdown-item list-group-item-action text-danger selectable" @click="logout">
              <i class="mdi mdi-logout"></i>
              logout
            </div>
          </div>
        </div>
      </div> -->
      <div class="drop-up">
        <div type="button" class=" drop-btn bg-dark border-0 no-select circle" @click="toggleShow()">
          <div v-if="account.picture || user.picture">
            <img :src="account.picture || user.picture" alt="account photo" class="account-photo circle" />
          </div>
        </div>
        <div id="loginDropMenu" class="drop-up-content rounded elevation-5 p-1">
          <router-link :to="{ name: 'Account' }">
            <div class="list-group-item dropdown-item list-group-item-action">
              Manage Account
            </div>
          </router-link>
          <div class="list-group-item dropdown-item list-group-item-action text-center text-danger selectable"
            @click="logout">
            <i class="mdi mdi-logout"></i>
            logout
          </div>
        </div>
      </div>
    </div>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      },
      toggleShow() {
        document.getElementById("loginDropMenu").classList.toggle("show")
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.circle {
  border-radius: 50%;
}

.account-photo {
  height: 53.3px;
  width: 53.3px;
}

.drop-up {
  position: relative;
  display: inline-block;
}

.drop-up-content {
  display: none;
  position: absolute;
  width: fit-content;
  background-color: white;
  bottom: 50%;
  left: -175px;
  z-index: 1;
}

.show {
  display: block;
}

.drop-up-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.drop-up-content a:hover {
  background-color: #ccc
}

.drop-up:hover .drop-btn {
  background-color: #2980B9;
}

@media screen and (min-width: 768px) {
  .account-photo {
    height: 64px;
    width: 64px;
  }

  .drop-up {
    position: relative;
    display: inline-block;
  }

  .drop-up-content {
    display: none;
    position: absolute;
    width: fit-content;
    bottom: -50%;
    left: -175px;
    z-index: 1;
    transition: 0.2 linear;
  }

  .drop-up:hover .drop-up-content {
    display: block;
  }

  .drop-up:hover .drop-btn {
    background-color: #2980B9;
  }

  .login-btn:hover { 
    color: white !important;
  }
}
</style>
