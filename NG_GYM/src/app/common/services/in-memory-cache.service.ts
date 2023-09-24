import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InMemoryCacheService<T> {

  private cache = new Map<string, { data: T, timestamp: number }>();

  private readonly MAX_ITEMS = 120;
  private readonly TTL = 1000 * 60 * 2; // in milliseconds

  protected set(key: string, value: T): void {
    if (this.cache.size >= this.MAX_ITEMS) {
      const oldestKey = Array.from(this.cache.keys())[0];
      this.cache.delete(oldestKey);
    }
    this.cache.set(key, { data: value, timestamp: Date.now() });
  }

  protected get(key: string): T | undefined {
    const cached = this.cache.get(key);
    
    if (!cached) {
      return undefined;
    }
    
    const now = Date.now();
    const isExpired = now - cached.timestamp > this.TTL;

    if (isExpired) {
      this.cache.delete(key);
      return undefined;
    }

    return cached.data;
  }

  protected delete(key: string): void {
    this.cache.delete(key);
  }

  protected clearAll(): void {
    this.cache.clear();
  }
}