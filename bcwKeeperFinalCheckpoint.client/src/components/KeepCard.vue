<template>
  <section class="keep-card mb-3 elevation-3 pos-relative">
    <div class="keep-card-wrapper pos-relative" @click="openModal()" aria-label="Open Keep Details Modal" title="Open Keep Details Modal">
      <img :src="keep?.img || keepInVault?.img" :alt="keep?.name || keepInVault?.name" class="keep-img">
      <div class="tags gap-2">
        <Tag v-for="t in keep?.tags" :key="t" :tag="t" />
      </div>
      <span class="text-visible keep-label text-start m-3">{{ keep?.name || keepInVault?.name }}</span>
    </div>
    <router-link :to="{ name: 'Profile', params: { profileId: keep?.creatorId || keepInVault?.creatorId } }">
      <img :src="keep?.creator.picture || keepInVault?.creator.picture" :alt="keep?.creator.name || keepInVault?.creator.name" :title="keep?.creator.name || keepInVault?.creator.name"
        class="profile-img selectable m-3" aria-label="Go to User Profile Page">
    </router-link>
    <i class="mdi mdi-close on-hover selectable delete-icon text-visible" aria-label="Delete Keep" title="Delete Keep" @click="deleteKeep()"
      v-if="(keep?.creatorId === account.id || keepInVault?.creatorId === account.id) && user.isAuthenticated"></i>
  </section>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { KeepInVault } from "../models/KeepInVault";
import { keepsService } from "../services/KeepsService";
import Pop from "../utils/Pop";

export default {
  props: {
    keep: { type: Keep },
    keepInVault: { type: KeepInVault }
  },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      async setActiveKeep() {
        try {
          if(props.keep) {
            await keepsService.setActiveKeep(props.keep)
          } else {
            await keepsService.setActiveKeep(props.keepInVault)
          }
        }
        catch(error) {
          Pop.error(error.message, "[setActiveKeep]")
        }
      },
      openModal() {
        this.setActiveKeep()
        let modal = document.getElementById(`keepDetailsModal`)
        let body = document.querySelector("body")
        body.style.overflow = "hidden"
        modal.style.display = "block"
      },
      async deleteKeep() {
        try {
          const yes = await Pop.confirm(`Do you want to delete ${props.keep?.name || props.keepInVault?.name}?`)
          if (!yes) {
            return
          }
          await keepsService.deleteKeep(props.keep?.id || props.keepInVault?.id)
          Pop.toast(`${props.keep?.name|| props.keepInVault?.name} has been deleted.`, "warning", "top")
        }
        catch (error) {
          Pop.error(error.message, "[deleteKeep]")
        }
      }
    };
  },
}
</script>

<style scoped lang="scss">
.keep-card {
  background-position: center;
  background-size: cover;
  width: 100%;
  border-radius: 6.94872px;
}

.keep-img {
  width: 100%;
  height: 100%;
}

.keep-card-wrapper {
  height: 100%;
  width: 100%;
}

.keep-card-wrapper:hover {
  cursor: pointer;
}

.delete-icon {
  position: absolute;
  right: 2%;
  top: 2%;
}

img {
  border-radius: 6.94872px;
}

.profile-img {
  display: none;
  filter: drop-shadow(0px 4.79889px 4.79889px rgba(0, 0, 0, 0.25));
}

.pos-relative {
  position: relative;
}

.keep-label {
  position: absolute;
  bottom: 10px;
  left: 0;
  width: 90%;
}

.tags {
  position: absolute;
  top: 0;
  left: 0;
  width: 90%;
  display: flex;
  flex-wrap: wrap;
}

@media screen and (min-width: 768px) {
  .keep-card {
    transition: 0.15s linear;
  }

  .keep-card:hover {
    transform: scale(1.03);
    filter: brightness(0.85);
  }

  .profile-img {
    display: block;
    border-radius: 50%;
    height: 40px;
    width: 40px;
    position: absolute;
    right: 0;
    bottom: 0;
  }
}
</style>