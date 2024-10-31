<template>
  <div class="homepage">
    <StatusBar />
    <TopAppBarWrapper />
    <Frame />
    <NavigationBarWrapper />
    <BuildingBlocks
      class="gesture-bar"
      handleClassName="building-blocks-navigation"
    />
  </div>
</template>

<script>
import StatusBar from "./StatusBar";
import TopAppBarWrapper from "./TopAppBarWrapper";
import Frame from "./Frame";
import NavigationBarWrapper from "./NavigationBarWrapper";
import BuildingBlocks from "./BuildingBlocks";

export default {
  name: "Homepage",
  components: {
    StatusBar,
    TopAppBarWrapper,
    Frame,
    NavigationBarWrapper,
    BuildingBlocks,
  },
};
</script>

<style>
.homepage {
  align-items: flex-start;
  background-color: #fef7ff;
  border: 8px solid;
  border-color: #cac4d0;
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  position: relative;
}

.homepage .gesture-bar {
  align-self: stretch !important;
  background-color: #f3edf7 !important;
  position: relative !important;
  width: 100% !important;
}

.homepage .building-blocks-navigation {
  left: 161px !important;
}
</style>