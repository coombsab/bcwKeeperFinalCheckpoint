<template>
  <div class="home p-3">
    <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState";
import KeepCard from "../components/KeepCard.vue";
import Tag from "../components/Tag.vue";
import { keepsService } from "../services/KeepsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      }
      catch (error) {
        Pop.error(error.message, "[getKeeps]")
      }
    }

    onMounted(() => {
      getKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { Tag, KeepCard }
}
</script>

<style scoped lang="scss">
.home {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .home {
    columns: 4;
  }
}
</style>
