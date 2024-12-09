import { TestBed } from '@angular/core/testing';

import { ArticleImageUploadService } from './article-image-upload.service';

describe('ArticleImageUploadService', () => {
  let service: ArticleImageUploadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArticleImageUploadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
