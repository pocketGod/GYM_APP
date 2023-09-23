import { CapacitorConfig } from '@capacitor/cli';

const config: CapacitorConfig = {
  appId: 'com.example.app',
  appName: 'ng-gym',
  webDir: 'dist/ng-gym',
  server: {
    androidScheme: 'https'
  }
};

export default config;
